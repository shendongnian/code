	public class BindableToolStripStatusLabel : ToolStripStatusLabel, IBindableComponent
	   
	public class BindableStatusBarLabel :  ToolStripLabel, IBindableComponent
	{
		private ControlBindingsCollection _bindings;
		private BindingContext _context;
		public BindingContext BindingContext
		{
			get
			{
				if (_context == null)
				{
					_context = new BindingContext();
				}
				return _context;
			}
			set
			{
				_context = value;
			}
		}
		public ControlBindingsCollection DataBindings
		{
			get
			{
				if (_bindings == null)
				{
					_bindings = new ControlBindingsCollection(this);
				}
				return _bindings;
			}
		}
	}
 
