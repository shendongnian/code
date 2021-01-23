    foreach (ActionPerformed ap in AllPLUs)
            {
                if (ap.File_Name == "PLU" && ap.Status == "Processed" && ap.Date.Month == DateTime.Today.Month)
                {
                    EndOfMonthPLUs.Add(ap);
                }
            }
