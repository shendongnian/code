    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    public partial class Form1
    {
        private DataTable gl_Permission = new DataTable();
        private string gl_FomCode;
        private string gl_FormName;
        private DateTime gl_dtServer;
        public Form1()
        {
            InitializeComponent();            
        }
        public Form1(DataTable Permission, string FormCode, string FormName, DateTime dtServer)
        {
            InitializeComponent();            
           // Add any initialization after the InitializeComponent() call.
            gl_Permission = Permission;
            gl_FomCode = FormCode;
            gl_FormName = FormName;
            gl_dtServer = dtServer;
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            Label2.Text = gl_FomCode;
            Label3.Text = gl_FormName;
        }
    }
