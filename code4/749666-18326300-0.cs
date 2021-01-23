        /// <summary>
        /// Populates HoursDuration List
        /// </summary>
        public void PopulateHoursDurationList()
        {
            HoursDurationList = new ObservableCollection<EmployeeClockSummary>();
            try
            {
                // Punches grouped by Employee
                foreach (var empInOuts in PayPeriodPunches
                    .OrderBy(x => x.ClockPunchDateTime)
                    .GroupBy(x => x.Employee))
                {
                    int empCount = 0;
                    foreach (var empPunch in empInOuts)
                    {
                        if (empPunch.ClockAction == ClockAction.In)
                        {
                            // Clock In
                            HoursDurationList.Add(new EmployeeClockSummary
                            {
                                Employee = empPunch.Employee,
                                ClockInTime = empPunch.ClockPunchDateTime
                            });
                        }
                        else
                        {
                            // Clock Out
                            if (empCount == 0)
                            {
                                // This emp first punch is clock out (emp was clock in on previous pp)
                                HoursDurationList.Add(new EmployeeClockSummary
                                {
                                    Employee = empPunch.Employee,
                                    ClockOutTime = empPunch.ClockPunchDateTime
                                });
                            }
                            else
                            {
                                // Add clockout to previous clock in entry
                                var last = HoursDurationList[HoursDurationList.Count - 1];
                                last.ClockOutTime = empPunch.ClockPunchDateTime;
                                HoursDurationList[HoursDurationList.Count - 1] = last;
                            }                            
                        }
                        empCount++;
                    }
                }
            }
            catch (Exception e)
            {
            }
            // Check for any missing ClockOuts ie still clocked in, ClockIns ie was clocked in at start
            ObservableCollection<EmployeeClockSummary> tempList = new ObservableCollection<EmployeeClockSummary>();
            foreach (var x in HoursDurationList)
            {
                var change = x;
                if (change.ClockOutTime == DateTime.MinValue
                    || change.ClockOutTime == null)
                {
                    // Set clock out date to now (or pp end if now passed it)
                    // as they are still clocked in
                    if (DateTime.Now > PayPeriodSelected.EndDateTime)
                    {
                        change.ClockOutTime = PayPeriodSelected.EndDateTime;
                    }
                    else
                    {
                        change.ClockOutTime = DateTime.Now;
                    }
                }
                // Set clock in date to beginning of PP
                // as they were already clocked in when it started
                if (change.ClockInTime == DateTime.MinValue
                    || change.ClockInTime == null)
                {
                    change.ClockInTime = PayPeriodSelected.BeginDateTime;
                }
                tempList.Add(change);
            }
            // Group by Employee
            HoursDurationList = tempList;
            HoursDurationListView = new ListCollectionView(HoursDurationList);
            HoursDurationListView.GroupDescriptions.Add(new PropertyGroupDescription("Employee"));
        }
