            [HttpPost]
        public ActionResult InsertSensorsInExistingPredefineView(FormCollection sensorCollection)
        {
            int[] sensorIds = sensorCollection["SensorID"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            List<bool> vals = sensorCollection["val"].Split(',').Select(x => Convert.ToBoolean(x)).ToList();
            List<bool> mins = sensorCollection["min"].Split(',').Select(x => Convert.ToBoolean(x)).ToList();
            List<bool> avgs = sensorCollection["avg"].Split(',').Select(x => Convert.ToBoolean(x)).ToList();
            List<bool> maxs = sensorCollection["max"].Split(',').Select(x => Convert.ToBoolean(x)).ToList();
            List<bool> sums = sensorCollection["sum"].Split(',').Select(x => Convert.ToBoolean(x)).ToList();
            List<bool> ints = sensorCollection["_int"].Split(',').Select(x => Convert.ToBoolean(x)).ToList();
            List<bool> adjustVals = new List<bool>();
            adjustVals.Add(vals[0]);
            adjustVals = RemoveFalseAfterTrue(vals, adjustVals);
            List<bool> adjustMins = new List<bool>();
            adjustMins.Add(mins[0]);
            adjustMins = RemoveFalseAfterTrue(mins, adjustMins);
            List<bool> adjustAvgs = new List<bool>();
            adjustAvgs.Add(avgs[0]);
            adjustAvgs = RemoveFalseAfterTrue(avgs, adjustAvgs);
            
            List<bool> adjustMaxs = new List<bool>();
            adjustMaxs.Add(maxs[0]);
            adjustMaxs = RemoveFalseAfterTrue(maxs, adjustMaxs);
            List<bool> adjustSums = new List<bool>();
            adjustSums.Add(sums[0]);
            adjustSums = RemoveFalseAfterTrue(sums, adjustSums);
            List<bool> adjustInts = new List<bool>();
            adjustInts.Add(ints[0]);
            adjustInts = RemoveFalseAfterTrue(ints, adjustInts);
            for (int i = 0; i < sensorIds.Count(); i++)
            {
                bool val = adjustVals[i];
                bool min = adjustMins[i];
                bool avg = adjustAvgs[i];
                bool max = adjustMaxs[i];
                bool sum = adjustSums[i];
                bool _int = adjustInts[i];
            }
            return null;
        }
        private static List<bool> RemoveFalseAfterTrue(List<bool> initialCheckboxValues, List<bool> adjustedInitialCheckboxValues)
        {
            for (int i = 1; i < initialCheckboxValues.Count; ++i)
            {
                if (initialCheckboxValues[i - 1] == false)
                {
                    adjustedInitialCheckboxValues.Add(initialCheckboxValues[i]);
                }
            }
            return adjustedInitialCheckboxValues;
        } 
