    MSProject.Tasks mspTask = Globals.ThisAddIn.Application.ActiveProject.Tasks;
     for (int i = 0; i < dsTaskList.Tables[0].Rows.Count; i++)
                {
    DataRow drTask = dsTaskList.Tables[0].Rows[i];
                            short outLevel = Convert.ToInt16(drTask["TASK_OUTLINE_LEVEL"]);
                            if (outLevel == 0)
                            {
                                continue;
                            }
                            mspTask.Add();
                         
                            Utility.Save_UID.Add(drTask["TASK_UID"].ToString());
                          
                            Utility.editText9Bycode = true;
                            mspTask[k].Text9 = drTask["TASK_UID"].ToString();
                            string strAss = ""; 
                            DataSet dsAss =       WebServiceCall.GetAssignments(drTask["TASK_UID"].ToString());
}
