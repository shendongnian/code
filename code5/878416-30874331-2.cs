    ///All of the original given references should not be removed only add to this list
    using System.Windows.Forms.Integration;    //Make sure this is part of your project references
    namespace ProjectName {
       public partial class XamlTextBox : UserControl {
           public ElementHost Parent {
               get { return _elementHost; }
           }
           private ElementHost _elementHost;
           public XamlTextBox(ElementHost elhost) {
               InitializeComponenet();
               _elementHost = elhost;
           }
           public void SetParentText() {
               Parent.Text = this.textBox1.Text;
           }
        }
    }
