    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using RDPCOMAPILib;
    using AxMSTSCLib;
    using System.Runtime.InteropServices;
    namespace TCP_to_RDP_Converter
    {
        public partial class Form1 : Form
        {
            public static RDPSession currentSession = null;
            public static void createSession()
            {
                currentSession = new RDPSession();
            }
            public static void Connect(RDPSession session)
            {
                session.OnAttendeeConnected += Incoming;
                session.Open();
            }
            public static void Disconnect(RDPSession session)
            {
                session.Close();
            }
            public static string getConnectionString(RDPSession session, String authString, 
                string group, string password, int clientLimit)
            {
                IRDPSRAPIInvitation invitation =
                    session.Invitations.CreateInvitation
                    (authString, group, password, clientLimit);
                            return invitation.ConnectionString;
            }
            private static void Incoming(object Guest)
            {
                IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;
                MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
            }
            /// <summary>
            /// Handle the form items
            /// </summary>
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                createSession();
                Connect(currentSession);
                textConnectionString.Text = getConnectionString(currentSession,
                    "Test","Group","",5);
            }
            private void button2_Click(object sender, EventArgs e)
            {
                Disconnect(currentSession);
            }
        }
    }
