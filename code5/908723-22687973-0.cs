    public void CompareMyObjects<TObject>(TObject object1, TObject object2)
        {
            var fields = typeof(TObject).GetFields();
            foreach (var field in fields)
            {
                Assert.AreEqual(object1, object2);
            }
        }
