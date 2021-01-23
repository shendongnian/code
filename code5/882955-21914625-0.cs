        if (this.lboxMachines.SelectedItems != null && this.lboxMachines.SelectedItems.Contains(GimaID))
        {											
            foreach (string MachineID in this.lboxMachines.SelectedItems)
            {
                for (int i = 0; i <= 23; i++)
                {
                    var PartsCast = (from p in ProductionEntity.PARTDATAs
                             where p.DATE_TIME >= StartDate
                             where p.DATE_TIME <= EndDate
                             where p.MACHINE == MachineID
                             select p).Count();
                    StartDate = StartDate.AddHours(1);
                    DT.Rows[row][col] = PartsCast;
                    col++;
                }
            }
        }
