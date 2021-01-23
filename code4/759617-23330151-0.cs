      [TestFixture]
      public class ExecuteCommandOnEnterBehaviorFixture
      {
        private ExecuteCommandOnEnterBehavior _keyboardEnterBehavior;
        private TextBox _textBox;
        private bool _enterWasCalled = false;
    
    
        [SetUp]
        public void Setup()
        {
          _textBox = new TextBox();
          _keyboardEnterBehavior = new ExecuteCommandOnEnterBehavior();
          _keyboardEnterBehavior.ExecuteCommand = new Microsoft.Practices.Composite.Presentation.Commands.DelegateCommand<object>((o) => { _enterWasCalled = true; });
          _keyboardEnterBehavior.Attach(_textBox);
        }
    
        [Test]
        [STAThread]
        public void AssociatedObjectClick_Test_with_ItemClick()
        {
          _textBox.RaiseEvent(
            new KeyEventArgs(
              Keyboard.PrimaryDevice,
              MockRepository.GenerateMock<PresentationSource>(),
              0,
              Key.Enter) { RoutedEvent = Keyboard.KeyDownEvent });
    
          Assert.That(_enterWasCalled);
        }
      }
