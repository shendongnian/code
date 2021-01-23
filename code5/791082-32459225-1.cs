    private void UploadUserInformationAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            EmployeeBiometric employeeBiometric = (EmployeeBiometric)View.SelectedObjects[0];
            EmployeeBiometricParameter param = (EmployeeBiometricParameter)e.PopupWindowViewCurrentObject;
            //create new czkemclass obj
            CZKEMClass myCZKEMClass = new CZKEMClass();
            //connecting the device
            myCZKEMClass.Connect_Net(param.Terminal.IPAddress, param.Terminal.Port);
            myCZKEMClass.EnableDevice(param.Terminal.DeviceId, false);
            
            int myCount = View.SelectedObjects.Count;
            //Set specific user to fingerprint device
            for (int i = 1; i <= myCount; i++)
            {
                int tMachineNo = param.Terminal.DeviceId;
                string tEnrollNo = employeeBiometric.Employee.EnrollNo;//Sequence.ToString();
                string tName = employeeBiometric.UserName;
                string tPassword = employeeBiometric.Password;
                int tPrivilege = (int)employeeBiometric.Privilege;
                bool tEnabled = employeeBiometric.Enabled;
                int tFingerIndex = employeeBiometric.FingerprintIndex;
                string tTmpData = employeeBiometric.FingerprintTemplate;
                int tFlag = 1;
                if (myCZKEMClass.SSR_SetUserInfo(tMachineNo, tEnrollNo, tName, tPassword, tPrivilege, tEnabled))
                {
                    myCZKEMClass.SetUserTmpExStr(tMachineNo, tEnrollNo, tFingerIndex, tFlag, tTmpData);
                }
            }
            myCZKEMClass.RefreshData(param.Terminal.DeviceId);
            myCZKEMClass.EnableDevice(param.Terminal.DeviceId, true);
        }
