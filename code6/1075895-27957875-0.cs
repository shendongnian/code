    public class MyViewModel : 
        Conductor<IScreen>.Collection.OneActive,
        IHandleWithTask<DatabaseItemChangedMessage>
    {
        // Ideally, async methods return a Task, but here you have to
        // match the base method signature, so you're stuck with void
        protected override async void OnInitialize()
        {
            base.OnInitialize();
            try
            {
                await this.LoadData(false);
            }
            catch (Exception e)
            {
                App.HandleException(e);
                this.TryClose();
            }    
        }
        // I added the "flag" parameter, so that it matched the calls from
        // your other code
        protected async Task LoadData(bool flag)
        {
            try
            {
                this.WorkStarted("Loading data...");
    
                TLoadedData loadedData;
                ISession transaction = null;
                // using (var transaction = this.DataItemRepository.BeginTransaction())
                // {
                     loadedData = await this.LoadDataInternal(transaction);
                //     transaction.Commit();
                // }
                // NOTE: by changing the caller of this method so that it's
                // initiated on the UI thread, now the continuations also run
                // on the UI thread, and you don't need to explicitly invoke them there.
                this.SetLoadedData(loadedData);
            }
            finally
            {
                this.WorkFinished();
            }
        }
    }
