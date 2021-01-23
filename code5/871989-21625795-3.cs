    class CalculatorFlyweightFactory
    {
        Dictionary<string, ISalaryScoreElement> calculators = new Dictionary<string, ISalaryScoreElement>();
        public int TotalObjectsCreated
        {
            get { return calculators.Count; }
        }
        public ISalaryScoreElement GetSalaryElement(string salaryKey)
        {
            ISalaryScoreElement c = null;
            if (calculators.ContainsKey(salaryKey))
            {
                c = calculators[salaryKey];
            }
            else
            {
                switch (salaryKey)
                {
                    case "BasicElement":
                        c = new BasicElement();
                        calculators.Add("BasicElement", c);
                        break;
                    case "StandardPointElement":
                        c = new StandardPointElement();
                        calculators.Add("StandardPointElement", c);
                        break;
                    default:
                        throw new Exception("Factory cannot create the object specified");
                }
            }
            return c;
        }
    }
