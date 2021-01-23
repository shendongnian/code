    private void DownloadUserInformationAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            Terminal terminal = (Terminal)View.SelectedObjects[0];
            //create new czkemclass obj
            CZKEMClass myCZKEMClass = new CZKEMClass();
            //connecting the device
            myCZKEMClass.Connect_Net(terminal.IPAddress, terminal.Port);
            //Initialize variable for store temporary user information
            int tMachineNo = 0;
            string tEnrollNo = "";
            string tName = "";
            string tPassword = "";
            int tPrivilage = 0;
            bool tEnabled = false;
            int tFingerIndex;
            int tFlag = 0;
            string tTemplateData = "";
            int tTemplateLength = 0;
            myCZKEMClass.EnableDevice(terminal.DeviceId, false);
            myCZKEMClass.ReadAllUserID(terminal.DeviceId);
            myCZKEMClass.ReadAllTemplate(terminal.DeviceId);
            while (myCZKEMClass.SSR_GetAllUserInfo(tMachineNo, out tEnrollNo, out tName, out tPassword, out tPrivilage, out tEnabled))
            {
                for (tFingerIndex = 0; tFingerIndex < 10; tFingerIndex++)
                {
                    if (myCZKEMClass.GetUserTmpExStr(tMachineNo, tEnrollNo, tFingerIndex, out tFlag, out tTemplateData, out tTemplateLength))
                    {
                        EmployeeBiometric employeeBiometric = new EmployeeBiometric(terminal.Session);
                        //employeeBiometric.EnrollNumber = tEnrollNo;
                        XPCollection<Employee> employees = new XPCollection<Employee>(terminal.Session);
                        employeeBiometric.Employee = employees.Where(emp => emp.EnrollNo == tEnrollNo).FirstOrDefault();//(emp => emp.Sequence.ToString() == tEnrollNo).FirstOrDefault();
                        employeeBiometric.UserName = tName;
                        employeeBiometric.Password = tPassword;
                        employeeBiometric.Privilege = (Privilege)Enum.ToObject(typeof(Privilege), tPrivilage);
                        employeeBiometric.Enabled = tEnabled;
                        employeeBiometric.FingerprintIndex = tFingerIndex;
                        employeeBiometric.FingerprintTemplate = tTemplateData;
                        employeeBiometric.TemplateLength = tTemplateLength;
                        terminal.Session.CommitTransaction();
                    }
                }
            }
            myCZKEMClass.EnableDevice(terminal.DeviceId, true);
        }
