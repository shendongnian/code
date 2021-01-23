    Expression<Func<SlotPool, IEnumerable<PatientSchedule>>> queryDay = null;
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    queryDay = d => d.MondayPatientSchedules;
                    break;
                case DayOfWeek.Thursday:
                    queryDay = d => d.MondayPatientSchedules;
                    break;
                // .. Not shown for brevity
                default:
                    throw new NotSupportedException("Unsupported DayOfWeek");
            }
            IEnumerable<UnitWithCountVM> data = _unitOfWork.Units.GetAll()
                .OrderBy(u => u.Name)
                .Select(u => new UnitWithCountVM()
                {
                    ID = u.ID,
                    Name = u.Name,
                    PatientNumber = u.SlotPools.AsQueryable().SelectMany(queryDay).Count()
                }).ToList();
