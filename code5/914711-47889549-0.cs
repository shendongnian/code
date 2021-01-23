	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Command;
	...
	public class SomeVm : ViewModelBase {
		public SomeVm() {
			SelectItemsCommand = new RelayCommand<IList>((items) => {
				Selected.Clear();
				foreach (var item in items) Selected.Add((SomeClass)item);
			});
			ViewCommand = new RelayCommand(() => {
				foreach (var selected in Selected) {
					// todo do something with selected items
				}
			});
		}
		public List<SomeClass> Selected { get; set; }
		public RelayCommand<IList> SelectionChangedCommand { get; set; }
		public RelayCommand ViewCommand { get; set; }
	}
