                if (DateTime.Now.TimeOfDay.TotalHours > 1 && DateTime.Now.TimeOfDay.TotalHours < 2)
                {
                    mem_details();
                    (sender as Timer).Enabled=false;
                }
            };`
