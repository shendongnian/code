        public void AssertSameDictionary<TKey,TValue>(Dictionary<TKey,TValue> expected,Dictionary<TKey,TValue> actual)
        {
            string d1 = "expected";
            string d2 = "actual";
            Dictionary<TKey,TValue>.KeyCollection keys1= expected.Keys;
            Dictionary<TKey,TValue>.KeyCollection keys2= actual.Keys;
            if (actual.Keys.Count > expected.Keys.Count)
            {
                string tmp = d1;
                d2 = d1;
                d1 = tmp;
                Dictionary<TKey, TValue>.KeyCollection tmpkeys = keys1;
                keys1 = keys2;
                keys2 = tmpkeys;
            }
            foreach(TKey key in keys1)
            {
                Assert.IsTrue(keys2.Contains(key), $"key '{key}' of {d1} dict was not found in {d2}");
            }
            foreach (TKey key in expected.Keys)
            {
                //already ensured they both have the same keys
                Assert.AreEqual(expected[key], actual[key], $"for key '{key}'");
            }
        }
