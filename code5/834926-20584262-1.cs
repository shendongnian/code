        foreach (PropertyData property in properties)
        {
            Console.WriteLine(property.Name);
            foreach (QualifierData q in property.Qualifiers)
            {
                if(q.Name.Equals("Description"))
                {
                    Console.WriteLine(
                        processClass.GetPropertyQualifierValue(
                        property.Name, q.Name));
                }
            }
            Console.WriteLine();
        }
