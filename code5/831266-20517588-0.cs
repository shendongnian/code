            dgvEvents.AutoGenerateColumns = false;
            dgvEvents.DataSource = context.Events.ToList();
            int row = 0;
            foreach (Event e in (List<Event>)context.Events.ToList())
            {
                string doorName = e.Door.DoorName;
                string userName = e.User.FullName;
                dgvEvents.Rows[row].Cells[2].Value = doorName;
                dgvEvents.Rows[row].Cells[1].Value = userName;
                row++;
            }
