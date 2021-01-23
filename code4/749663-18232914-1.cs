        /// <summary>
        /// Populates HoursSummary List
        /// </summary>
        public void PopulateHoursSummaryList()
        {
            HoursSummaryList = new List<EmployeeClockSummary>();
            // Get list of time clock punches
            PayPeriodPunches = new List<TimeClock>();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            using (var db = new Database())
            {
                // Load with Employee
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<TimeClock>(tc => tc.Employee);
                db.LoadOptions = dlo;
                PayPeriodPunches = db.TimeClockPunches
                    .Where(cp => cp.ClockPunchDateTime >= PayPeriodSelected.BeginDateTime
                                && cp.ClockPunchDateTime <= PayPeriodSelected.EndDateTime)
                    .OrderBy(cp => cp.ClockPunchDateTime)
                    .ToList();
            }
            // Get unique list of employees and sum of hours worked
            HoursWorkedList = new List<EmployeeHoursWorked>();
            foreach (TimeClock tcp in PayPeriodPunches)
            {
                if (!HoursWorkedList.Exists(e => e.Employee == tcp.Employee))
                {
                    EmployeeHoursWorked ehw = new EmployeeHoursWorked();
                    ehw.Employee = tcp.Employee;
                    HoursWorkedList.Add(ehw);
                }
            }
            foreach (EmployeeHoursWorked ehw in HoursWorkedList.ToList())
            {
                Employee e = ehw.Employee;
                // This employees punches
                List<TimeClock> thisEmpPunches = PayPeriodPunches
                    .Where(pp => pp.Employee == e)
                    .OrderBy(pp => pp.ClockPunchDateTime)
                    .ToList();
                bool hasClockedIn = false;
                bool hasClockedOut = false;
                int i = 0;
                DateTime dts = new DateTime();
                DateTime dte = new DateTime();
                TimeSpan dur = new TimeSpan();
                foreach (TimeClock tcp in thisEmpPunches)
                {
                    if (tcp.ClockAction == ClockAction.In)
                    {
                        dts = tcp.ClockPunchDateTime;
                        hasClockedIn = true;
                        i = 1;
                    }
                    if (tcp.ClockAction == ClockAction.Out)
                    {
                        dte = tcp.ClockPunchDateTime;
                        // Was clocked In: Use previous clock-in time
                        if (i == 1)
                        {
                            dur = dte - dts;
                            EmployeeClockSummary ecs = new EmployeeClockSummary();
                            ecs.Employee = e;
                            ecs.ClockInTime = dts;
                            ecs.ClockOutTime = dte;
                            HoursSummaryList.Add(ecs);
                        }
                        else
                        {
                            // Not clocked in, never clocked in, assume clocked in since beginning of PP
                            if (!hasClockedIn)
                            {
                                dts = PayPeriodSelected.BeginDateTime;
                                dur = dte - dts;
                                EmployeeClockSummary ecs = new EmployeeClockSummary();
                                ecs.Employee = e;
                                ecs.ClockInTime = dts;
                                ecs.ClockOutTime = dte;
                                HoursSummaryList.Add(ecs);
                            }
                        }
                        
                        // Update employee hours worked duration
                        int index = HoursWorkedList.FindIndex(z => z.Employee == e);
                        EmployeeHoursWorked tmp = HoursWorkedList[index];
                        tmp.HoursWorked += dur;
                        HoursWorkedList[index] = tmp;
                        hasClockedOut = true;
                        i = 2;
                    }
                }
                if (i == 1)
                {
                    // Employee never clocked out, assume end of PP (or now if sooner)
                    if (DateTime.Now < PayPeriodSelected.EndDateTime)
                    {
                        dte = DateTime.Now;
                    }
                    else
                    {
                        dte = PayPeriodSelected.EndDateTime;
                    }
                    EmployeeClockSummary ecs = new EmployeeClockSummary();
                    ecs.Employee = e;
                    ecs.ClockInTime = dts;
                    ecs.ClockOutTime = dte;
                    HoursSummaryList.Add(ecs);
                    // Update employee hours worked duration
                    dur = dte - dts;
                    int index = HoursWorkedList.FindIndex(z => z.Employee == e);
                    EmployeeHoursWorked tmp = HoursWorkedList[index];
                    tmp.HoursWorked += dur;
                    HoursWorkedList[index] = tmp;
                }
                if (HoursSummaryList.Any())
                {
                }
            }
        }
