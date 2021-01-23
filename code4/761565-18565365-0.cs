            var expresionData = new List<DataPoint>();
            Regex pattern = new Regex("[x]");
            for (int i = 0; i < 100; i++)
            {
                string a = pattern.Replace(ExpresionString, i.ToString());
                NCalc.Expression exp = new NCalc.Expression(a);
                expresionData.Add(new DataPoint(i,Double.Parse(exp.Evaluate().ToString())));
            }
