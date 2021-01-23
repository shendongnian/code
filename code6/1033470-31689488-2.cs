	public class ScreenViewModel
	{
		[Inject] public CustomerService CustomerService { get; set; }
		[Inject] public SalesService SalesService { get; set; }
		[Inject] public BillService BillService { get; set; }
		...etc...
	}
