    public class CustomAutoComplete : AutoCompleteBox
    {
    TextBox mytext;
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        mytext = GetTemplateChild("Text") as TextBox;
        mytext.TextChanged += new System.Windows.Controls.TextChangedEventHandler(mytext_TextChanged);
    }
    void mytext_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        this.Text = mytext.Text;
        OnTextChanged(new RoutedEventArgs());
    }
}
