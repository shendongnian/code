    using System.Windows.Controls;
    using System.Windows.Interactivity;
    namespace WpfApplication2
    {
        public class AutoScrollToHomeBehavior : Behavior<TextBox>
        {
            protected override void OnAttached()
            {
                AssociatedObject.LostFocus += (tb, args) =>
                    {
                        (tb as TextBox).ScrollToHome();
                    };
            }
        }
    }
