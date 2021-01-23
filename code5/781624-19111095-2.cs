    public void Test(Dictionary<int, bool> dic) {
      //optional, stops people calling Test(null) where you want them to call Test():
      if(dic == null) throw new ArgumentNullException("dic");
    ...
    }
    public void Test() {
       var defaultDic = new Dictionary<int, bool>();
       Test(defaultDic);
    }
