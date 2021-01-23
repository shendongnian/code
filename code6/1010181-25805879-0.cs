    [TestFixture]
        class GameTests
        {
    
            [Test]
            public void AddKeyValuePair()
            {
                var levelProgress = new Dictionary<int, KeyValuePair<string, int>>();
                KeyValuePair<string, int> storedValue;
                if (levelProgress.TryGetValue(1, out storedValue))
                {
                    Assert.Fail("shouldn't get here");
                }
                else
                {
                    levelProgress[1] = new KeyValuePair<string, int>("something", 1);
                }
    
                Assert.IsTrue(levelProgress.ContainsKey(1));
                Assert.IsTrue(levelProgress[1].Equals(new KeyValuePair<string, int>("something", 1)));
            }
    
            [Test]
            public void UpdateKeyValuePair()
            {
                var levelProgress = new Dictionary<int, KeyValuePair<string, int>>
                {
                    {1, new KeyValuePair<string, int>("something", 1)}
                };
                KeyValuePair<string, int> storedValue;
                if (levelProgress.TryGetValue(1, out storedValue))
                {
                    levelProgress[1] = new KeyValuePair<string, int>(storedValue.Key, storedValue.Value+1);
                }
                else
                {
                    Assert.Fail("shouldn't get here");
                }
    
                Assert.IsTrue(levelProgress.ContainsKey(1));
                Assert.IsTrue(levelProgress[1].Equals(new KeyValuePair<string, int>("something", 2)));
            }
        }
