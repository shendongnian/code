            sDataRow dr = newdt.Rows[i];
            
            object value = dr["Trainee"];
            if (value != DBNull.Value)
            {
                string TempTr = dr["Trainee"].ToString();
                string[] result = TempTr.Split(',');
                foreach (string s in result)
                {
                    if (s.Trim() != "")
                        TraineeCombo.Items.Add(s);
                }
            }
