        {   
            string subjId;   
            List<string> lines = new List<string>();   
            for (int i = 0; i < gvSubjectsList.Rows.Count; i++)   
            {   
           bool Ischecked =Convert.ToBoolean(gvSubjectsList.Rows[i].Cells["Select"].Value);    
                if (Ischecked == true)   
                {   
                    subjId = gvSubjectsList.Rows[i].Cells["SubjectId"].Value.ToString();   
                    lines.Add(subjId);   
                }   
        }
        comboBox1.DataSource = lines;     
            
        }  
