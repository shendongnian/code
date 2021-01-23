    var data = File.ReadAllLines(@"C:\Desktop\test.csv")
                   .Select(line => line.Split(','))
                   .Select(parts => new
                    {
                        ClientNumber = parts[0].Trim(),
                        Name = parts[1].Trim(),
                        BenefitCode = parts[2].Trim(),
                        EffectiveDate = parts[3].Trim()
                    })
                    .GroupBy(x => x.ClientNumber);
