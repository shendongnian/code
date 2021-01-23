	public class ViewModelList : List<ViewModel>
	{
		public void UpdateAllPoints(List<int> list1, List<int> list2)
		{
			this.Clear();
			foreach (var item in list1)
			{
				var viewModel = new ViewModel();
				viewModel.SetPoints(list1, list2);
				this.Add(viewModel);
			}
		}
	}
