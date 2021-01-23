        public int GetTotalAnnualSalary()
        {
            int totalSalary = 0;
            ISalaryScoreElement sal = null;
            CalculatorFlyweightFactory flyweightFactory = new CalculatorFlyweightFactory();
            foreach (string salaryType in EligibleSalaryTypes)
            {
                switch (salaryType)
                {
                    case "Basic":
                        sal = flyweightFactory.GetSalaryElement("BasicElement");
                        break;
                    case "ReferralPoint":
                        sal = flyweightFactory.GetSalaryElement("StandardPointElement");
                        break;
                    case "BrandingPoint":
                        sal = flyweightFactory.GetSalaryElement("StandardPointElement");
                        break;
                    case "RecognitionPoint":
                        sal = flyweightFactory.GetSalaryElement("StandardPointElement");
                        break;
                    case "StarPerformerPoint":
                        sal = flyweightFactory.GetSalaryElement("StandardPointElement");
                        break;
                    default:
                        throw new Exception("No mapping available");
                }
                if (sal is StandardPointElement && sal.OccurenceCount >= 4)
                {
                    //StandardPointElement can be considered a maximum of 2 times for salary calculation
                    continue;
                }
                sal.OccurenceCount = sal.OccurenceCount + 1;
                totalSalary = totalSalary + sal.SalaryScore;
            }
            return totalSalary;
        }
