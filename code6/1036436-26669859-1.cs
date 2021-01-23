    public class DataContextPresenter : Presenter<IDataContextView>
    {
        public DataContextPresenter(IDataContextView view)
            : base(view)
        {
            this.View.Update += OnUpdating();
        }
        private void OnUpdating(object sender, ModelStateEventArgs e)
        {
			var entity = ConvertViewModelToEntity(this.View.Model);
			dbcontext.Entry(entity).State = EntityState.Modified;
			try
			{
				dbcontext.SaveChanges();
			}
			catch (DbUpdateException updateException)
			{
				// add the error to the model state for display by the view
				e.ModelState.AddModelError(string.Empty, updateException.GetBaseException().Message);
			}
        }
    }
