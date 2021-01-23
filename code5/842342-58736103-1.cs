cs
<Frame Name="Main" Content="" Margin="127,0,0,0" Background="#FFFFEDED" />
For navigation:
1- Navigating from the main windows on button click:
cs
private void Button_Click(object sender, RoutedEventArgs e)
{
   // navigate to pages/projects.xaml inside the main frame
   Main.Content = new MyProject.Pages.Projects();
}
2- In case of navigation from the page inside a frame ex `Projects.xaml`
cs
// declare a extension method in a static class (its your choice if you want to reuse)
// name the class PageExtensions (you can choose any name)
namespace MyProject
{
    public static class PageExtensions
    {
        public static void NavigateTo(this Page page, string path)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(page);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }
            if (pageFrame != null)
            {
                pageFrame.Source = new Uri(path, UriKind.Relative);
            }
        }
    }
}
// to navigate from 'pages/projects.xaml' to another page
// heres how to call the extension on button click
this.NavigateTo("NewProject.xaml");
In addition, you can add another extension method that expects another `Page` object, in case you want to pass parameters to the constructor
cs
// overloading NavigateTo
public static void NavigateTo(this Page page, Page anotherPage)
{
    Frame pageFrame = null;
    DependencyObject currParent = VisualTreeHelper.GetParent(page);
    while (currParent != null && pageFrame == null)
    {
        pageFrame = currParent as Frame;
        currParent = VisualTreeHelper.GetParent(currParent);
    }
    // Change the page of the frame.
    if (pageFrame != null)
    {
        pageFrame.Navigate(anotherPage);
    }
}
// usage
this.NavigateTo(new Pages.EditProject(id));
