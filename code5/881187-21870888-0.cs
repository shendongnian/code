    public void DoSomething() {
        try {
            this.Name = "Test";
        } catch (Exception e) {
            var method = System.Reflection.MethodBase.GetCurrentMethod();
            var methodName = method.Name;
            var className = method.ReflectedType.Name;
            MainForm.Instance.LogException(String.Format("{0} - {1}:{2}", className, methodName, e));
        }
