    String strPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    String path = Path.Combine(strPath,"Patients","Patient_" + pid);
    string visitdate = db.GetPatient_visitDate(pid);
    this.visitNo = db.GetPatientID_visitNo(pid);
    string fileName = string.Format("visit_{0}_{1}", visitNo, visitdate);
    string visit_Path = Path.Combine(path, fileName);
    bool IsVisitExist = System.IO.Directory.Exists(path);
    bool IsVisitPath=System.IO.Directory.Exists(visit_Path);
