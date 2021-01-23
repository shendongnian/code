	// ...
	var set = this.CreateBindingSet<LocationFilterView, LocationFilterViewModel>();
	var selectAll = new ActivityElement { Caption = "All", Animating = false, ShouldDeselectAfterTouch = true };
	set.Bind(selectAll).For(v => v.SelectedCommand).To(vm => vm.SelectAllCommand).TwoWay();
	sectionButtons.Add(selectAll);
	var selectNone = new ActivityElement { Caption = "None", Animating = false, ShouldDeselectAfterTouch = true };
	set.Bind(selectNone).For(v => v.SelectedCommand).To(vm => vm.SelectNoneCommand).TwoWay();
	sectionButtons.Add(selectNone);
	var checkListItemViewModels = this.ViewModel.As<LocationFilterViewModel>().CheckList;
	foreach (var view in checkListItemViewModels.Select(checkListItem => new CheckListItemView { ViewModel = checkListItem }))
	{
		view.CheckboxElement.Caption = view.ViewModel.Caption;
		section.Add(view.CheckboxElement);
	}
	set.Apply();
    // ...
	public class CheckListItemView : BaseView
	{
		public CheckListItemView()
		{
			var set = this.CreateBindingSet<CheckListItemView, CheckListItemViewModel>();
			var item = new CheckboxElement();
			set.Bind(item).For(v => v.Value).To(vm => vm.IsChecked).TwoWay();
			set.Apply();
			this.CheckboxElement = item;
		}
		public new CheckListItemViewModel ViewModel
		{
			get { return base.ViewModel.As<CheckListItemViewModel>(); }
			set { base.ViewModel = value; }
		}
		public Element CheckboxElement { get; set; }
	}
