    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using Nektra.Deviare2;
    namespace PrintLogger
    {
        public partial class PrintLogger : Form
        {
            private NktSpyMgr _spyMgr;
            private NktProcess _process;
            public PrintLogger()
            {
                InitializeComponent();
                _spyMgr = new NktSpyMgr();
                _spyMgr.Initialize();
                _spyMgr.OnFunctionCalled += new DNktSpyMgrEvents_OnFunctionCalledEventHandler(OnFunctionCalled);
                GetProcess("notepad++.exe");
                if (_process == null)
                {
                    MessageBox.Show("Please start \"notepad++.exe\" before!", "Error");
                    Environment.Exit(0);
                }
            }
            private void PrintLogger_Load(object sender, EventArgs e)
            {
                NktHook hook = _spyMgr.CreateHook("user32.dll!ShowWindow", (int)(eNktHookFlags.flgOnlyPostCall));
                hook.Hook(true);
                hook.Attach(_process, true);
            }
            private bool GetProcess(string proccessName)
            {
                NktProcessesEnum enumProcess = _spyMgr.Processes();
                NktProcess tempProcess = enumProcess.First();
                while (tempProcess != null)
                {
                    if (tempProcess.Name.Equals(proccessName, StringComparison.InvariantCultureIgnoreCase) && tempProcess.PlatformBits > 0 && tempProcess.PlatformBits <= IntPtr.Size * 8)
                    {
                        _process = tempProcess;
                        return true;
                    }
                    tempProcess = enumProcess.Next();
                }
                _process = null;
                return false;
            }
            private void OnFunctionCalled(NktHook hook, NktProcess process, NktHookCallInfo hookCallInfo)
            {
                Output(hook.FunctionName + "( ");
                bool first = true;
                foreach (INktParam param in hookCallInfo.Params())
                {
                    if (first)
                        first = false;
                    else
                    {
                        Output(", ");
                    }
                    Output(param.Name + " = " + param.Value.ToString());
                }
                Output(" )" + Environment.NewLine);
            }
            public delegate void OutputDelegate(string strOutput);
            private void Output(string strOutput)
            {
                if (InvokeRequired)
                    BeginInvoke(new OutputDelegate(Output), strOutput);
                else
                    textOutput.AppendText(strOutput);
            }
        }
    }
