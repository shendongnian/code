    public class Activity1 : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var stupidStuff = new[] {"One", "Two", "Three"};
            ListAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, stupidStuff);
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            System.Diagnostics.Debug.WriteLine("Item {0} clicked", position + 1);
        }
    }
