    using (ABCEntities ctx = new ABCEntities())
        {
            var query = (from c in ctx.Cities
                        join s in ctx.States
                        on c.StateId equals s.StateId
                        where c.Pincode == iPincode
                        select new {
                                s.StateName, 
                                c.CityName, 
                                c.Area}).First().SingleOrDefault();
            if (query != null)
            {
                cboState.SelectedItem.Text =query.State;        
                cboCity.SelectedItem.Text = query.CityName;    
                txtArea.Text = query.Area;                        
            }
        }
