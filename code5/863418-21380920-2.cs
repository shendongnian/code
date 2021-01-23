    public partial class YourForm : Form
    {
        private readonly BackgroundWordFilter _filter;
        public YourForm()
        {
            InitializeComponent();
            
            // setup the background worker to return no more than 10 items,
            // and to set ListBox.DataSource when results are ready
            _filter = new BackgroundWordFilter
            (
                items: GetDictionaryItems(),
                maxItemsToMatch: 10,
                callback: results => 
                  this.Invoke(new Action(() => listBox_choices.DataSource = results))
            );
        }
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            // this will update the background worker's "current entry"
            _filter.SetCurrentEntry(textBox_search.Text);
        }
    }
