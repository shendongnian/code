     private void TestCaseChangeUserSeetingColor(object windowReference)
     {
          MyInputHandlerClass testUI = new MyInputHandlerClass(windowReference);
          testUI.Click('button1');
          testUI.Click('button2');
          testUI.Click('buttonblue');
          Assert.IsFalse(this.Application.ColorSetting.IsBlue);
     }
