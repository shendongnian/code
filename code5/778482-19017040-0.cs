    Mapper.CreateMap<PersonDb, Person>()
        .AfterMap((src, dest) => {
            dest.Salary = new Money();
            dest.Salary.Amount = src.SalaryAmount;
            dest.Salary.CurrencyCode = enum.Parse(typeof(CurrencyCodeType), src.SalaryCurrencyCode);
        });
