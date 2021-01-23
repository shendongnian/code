            // Simply initialize a list of your new class
            List<PairedValues> pairedValues = new List<PairedValues>();
            // add you object to the list anonymously 
            pairedValues.Add(new PairedValues("string1","string2","string3"));
            pairedValues.Add(new PairedValues("string1", "string2", "string3"));
            // Accessing the values
            foreach (PairedValues pair in pairedValues)
            {
                string value1 = pair.value1;
                string value2 = pair.value2;
                string value3 = pair.value3;
            }
