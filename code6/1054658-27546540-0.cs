    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net.NetworkInformation;
    using System.Threading;
    using System.Diagnostics;
    using System.Net;
    namespace WindowsFormsApplication3
    {
    public partial class Form1 : Form
    {
        private static List<Ping> pingers = new List<Ping>();
        private static int instances = 0;
        private static object @lock = new object();
        private static int result = 0;
        private static int timeOut = 250;
        private static int ttl = 5;
        private static string[] IPs=new string[100];
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string baseIP = "192.168.1.";
            IP.Items.Add("Pinging 255 destinations of D-class in " + baseIP+"xxx");
            CreatePingers(255);
           
            PingOptions po = new PingOptions(ttl, true);
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            byte[] data = enc.GetBytes("abababababababababababababababab");
            SpinWait wait = new SpinWait();
            int cnt = 1;
            Stopwatch watch = Stopwatch.StartNew();
            foreach (Ping p in pingers)
            {
                lock (@lock)
                {
                    instances += 1;
                }
                p.SendAsync(string.Concat(baseIP, cnt.ToString()), timeOut, data, po);
                cnt += 1;
            }
          
        }
        public static void Ping_completed(object s, PingCompletedEventArgs e)
        {
            lock (@lock)
            {
                instances -= 1;
            }
            if (e.Reply.Status == IPStatus.Success)
            {
                Console.WriteLine(string.Concat("Active IP: ", e.Reply.Address.ToString()));
                IPs[result] = e.Reply.Address.ToString();
                result += 1;
            }
            else
            {
                //Console.WriteLine(String.Concat("Non-active IP: ", e.Reply.Address.ToString()))
            }
        }
        private static void CreatePingers(int cnt)
        {
            for (int i = 1; i <= cnt; i++)
            {
                Ping p = new Ping();
                p.PingCompleted += Ping_completed;
                pingers.Add(p);
            }
        }
        private static void DestroyPingers()
        {
            foreach (Ping p in pingers)
            {
                p.PingCompleted -= Ping_completed;
                p.Dispose();
            }
            pingers.Clear();
        }
