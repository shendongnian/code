     using System.Windows;
     ...
     public class Student : DependencyObject
     {
		//FirstName Dependency Property
		public string FirstName
		{
			get { return (string)GetValue(FirstNameProperty); }
			set { SetValue(FirstNameProperty, value); }
		}
		public static readonly DependencyProperty FirstNameProperty =
			DependencyProperty.Register("FirstName", typeof(string), typeof(Student), new UIPropertyMetadata(null));
      }
