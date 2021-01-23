    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using System.Windows.Threading;
    using ActiproSoftware.Windows.Controls.Docking;
    
    // using ActiproSoftware.ProductSamples.DockingSamples.Common.ViewModels;
    
    namespace ActiProUtil
    {
    	public delegate void ActiveModelChangedHandler(object sender, DependencyPropertyChangedEventArgs eventArgs);
    
    	/// <summary>
    	/// EO: Provides attached behaviors for <see cref="DockSite"/> that properly initializes/opens windows associated
    	/// with view-models. Proper behavior depends on the Model staying the DataContext of the view
    	/// </summary>
    	public class DockSiteViewModelBehavior : Behavior<DockSite>
    	{
    		// ******************************************************************
    		/// <summary>
    		/// Identifies the <c>IsManaged</c> attached dependency property.  This field is read-only.
    		/// </summary>
    		/// <value>The identifier for the <c>IsManaged</c> attached dependency property.</value>
    		public static readonly DependencyProperty IsManagedProperty = DependencyProperty.Register("IsManaged",
    			typeof(bool), typeof(DockSiteViewModelBehavior), new FrameworkPropertyMetadata(false, OnIsManagedPropertyValueChanged));
    
    		/// <summary>
    		/// Identifies the <c>WindowsPendingOpen</c> attached dependency property.  This field is read-only.
    		/// </summary>
    		/// <value>The identifier for the <c>WindowsPendingOpen</c> attached dependency property.</value>
    		private static readonly DependencyProperty WindowsPendingOpenProperty = DependencyProperty.Register("WindowsPendingOpen",
    			typeof(IList<DockingWindow>), typeof(DockSiteViewModelBehavior), new FrameworkPropertyMetadata(null));
    
    		public static readonly DependencyProperty ActiveModelProperty = DependencyProperty.Register("ActiveModel",
    			typeof (object), typeof (DockSiteViewModelBehavior), new FrameworkPropertyMetadata(null, OnActiveModelChanged));
    
    		//public static readonly RoutedEvent OnModelActiveChnagedEvent = EventManager.RegisterRoutedEvent(
    		//	"OnModelActiveChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (DockSiteViewModelBehavior));
    
    		public static readonly DependencyProperty ModelsSourceProperty = DependencyProperty.Register("ModelsSource",
    			typeof(object), typeof(DockSiteViewModelBehavior), new FrameworkPropertyMetadata(null, OnDocumentSourceChanged));
    
    		public event ActiveModelChangedHandler ActiveModelChanged;
    		
    		// ******************************************************************
    		private DockSite _dockSite = null;
    
    		// ******************************************************************
    		private DockSite DockSite
    		{
    			get
    			{
    				if (_dockSite == null)
    				{
    					_dockSite = AssociatedObject;
    				}
    				
    				return _dockSite;
    			}
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Gets the first <see cref="ToolWindow"/> associated with the specified dock group.
    		/// </summary>
    		/// <param name="dockSite">The dock site to search.</param>
    		/// <param name="dockGroup">The dock group.</param>
    		/// <returns>
    		/// A <see cref="ToolWindow"/>; otherwise, <see langword="null"/>.
    		/// </returns>
    		private static ToolWindow GetToolWindow(DockSite dockSite, string dockGroup)
    		{
    			if (dockSite != null && !string.IsNullOrEmpty(dockGroup))
    			{
    				foreach (ToolWindow toolWindow in dockSite.ToolWindows)
    				{
    					ToolItemViewModel toolItemViewModel = toolWindow.DataContext as ToolItemViewModel;
    					if (toolItemViewModel != null && toolItemViewModel.DockGroup == dockGroup)
    						return toolWindow;
    				}
    			}
    
    			return null;
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Handles the <c>Loaded</c> event of the <c>DockSite</c> control.
    		/// </summary>
    		/// <param name="sender">The source of the event.</param>
    		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    		private void OnDockSiteLoaded(object sender, RoutedEventArgs e)
    		{
    			// Open any windows that were waiting for the DockSite to be loaded
    			IList<DockingWindow> windowsPendingOpen = DockSite.GetValue(WindowsPendingOpenProperty) as IList<DockingWindow>;
    			DockSite.ClearValue(WindowsPendingOpenProperty);
    
    			if (windowsPendingOpen != null && windowsPendingOpen.Count != 0)
    			{
    				foreach (DockingWindow dockingWindow in windowsPendingOpen)
    					OpenDockingWindow(DockSite, dockingWindow);
    			}
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Handles the <c>WindowRegistered</c> event of the <c>DockSite</c> control.
    		/// </summary>
    		/// <param name="sender">The source of the event.</param>
    		/// <param name="e">The <see cref="DockingWindowEventArgs"/> instance containing the event data.</param>
    		private void OnDockSiteWindowRegistered(object sender, DockingWindowEventArgs e)
    		{
    			var dockSite = sender as DockSite;
    			if (dockSite == null)
    				throw new ArgumentException("DockSiteViewModelBehavior is dedicated to actipro DockSite");
    
    			// Ensure the DockingWindow exists and is generated for an item
    			DockingWindow dockingWindow = e.Window;
    			if (dockingWindow == null || !dockingWindow.IsContainerForItem)
    				return;
    
    			// Pass down the name, if any as this cannot be done via a Style
    			if (string.IsNullOrEmpty(dockingWindow.Name))
    			{
    				ViewModelBase viewModel = dockingWindow.DataContext as ViewModelBase;
    				if (viewModel != null && !string.IsNullOrEmpty(viewModel.Name))
    					dockingWindow.Name = viewModel.Name;
    			}
    
    			// Open the DockingWindow, if it's not already open
    			if (!dockingWindow.IsOpen)
    			{
    				if (!dockSite.IsLoaded)
    				{
    					// Need to delay the opening until after the DockSite is loaded because it's content will not be loaded
    					IList<DockingWindow> windowsPendingOpen = dockSite.GetValue(WindowsPendingOpenProperty) as IList<DockingWindow>;
    					if (windowsPendingOpen == null)
    					{
    						windowsPendingOpen = new List<DockingWindow>();
    						dockSite.SetValue(WindowsPendingOpenProperty, windowsPendingOpen);
    					}
    
    					windowsPendingOpen.Add(dockingWindow);
    				}
    				else
    				{
    					OpenDockingWindow(dockSite, dockingWindow);
    
    					// EO: To fix a bug in event "LastActiveDocument" which does not trig on initial window.
    					dockSite.Dispatcher.BeginInvoke(new Action(() =>
    					{
    						if (dockSite.DocumentWindows.Count == 1)
    						{
    							dockingWindow.Activate();
    						}
    					}), DispatcherPriority.ContextIdle);
    				}
    			}
    		}
    
    		// ******************************************************************
    		private void EnsureDockingWindowAssociatedModelIsClose(DockingWindow dockingWindow)
    		{
    			if (dockingWindow != null)
    			{
    				object model = GetDockinWindowDataContext(dockingWindow);
    
    				if (model != null)
    				{
    					var iList = ModelsSource as IList;
    					if (iList != null)
    					{
    						iList.Remove(model);
    					}
    				}
    			}
    		}
    		
    		// ******************************************************************
    		/// <summary>
    		/// Handles the <c>WindowUnregistered</c> event of the <c>DockSite</c> control.
    		/// </summary>
    		/// <param name="sender">The source of the event.</param>
    		/// <param name="e">The <see cref="DockingWindowEventArgs"/> instance containing the event data.</param>
    		private void OnDockSiteWindowUnregistered(object sender, DockingWindowEventArgs e)
    		{
    			DockSite dockSite = sender as DockSite;
    			if (dockSite == null)
    				return;
    
    			// Ensure the DockingWindow exists and is generated for an item
    			DockingWindow dockingWindow = e.Window;
    			if (dockingWindow == null || !dockingWindow.IsContainerForItem)
    				return;
    
    			// Need to remove the window from the list of windows that are waiting to be opened
    			IList<DockingWindow> windowsPendingOpen = dockSite.GetValue(WindowsPendingOpenProperty) as IList<DockingWindow>;
    			if (windowsPendingOpen != null)
    			{
    				int index = windowsPendingOpen.IndexOf(dockingWindow);
    				if (index != -1)
    				{
    					EnsureDockingWindowAssociatedModelIsClose(dockingWindow);
    
    					windowsPendingOpen.RemoveAt(index);
    				}
    			}
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Called when <see cref="IsManagedProperty"/> is changed.
    		/// </summary>
    		/// <param name="d">The dependency object that was changed.</param>
    		/// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    		private static void OnIsManagedPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			var dockSiteViewModelBehavior = d as DockSiteViewModelBehavior;
    			if (dockSiteViewModelBehavior == null)
    			{
    				return;
    			}
    		}
    
    		// ******************************************************************
    		protected override void OnAttached()
    		{
    			base.OnAttached();
    
    			var dockSite = DockSite;
    
    			// Add/Remove handlers for various events, which will allow us to open/position generated windows
    			if (IsManaged)
    			{
    				dockSite.Loaded += OnDockSiteLoaded;
    				dockSite.WindowRegistered += OnDockSiteWindowRegistered;
    				dockSite.WindowUnregistered += OnDockSiteWindowUnregistered;
    
    
    				// EO 2014-12-10, Added next lines
    				dockSite.WindowClosing += dockSite_WindowClosing;
    				dockSite.LastActiveDocumentChanged += DockSiteOnLastActiveDocumentChanged;
    			}
    			else
    			{
    				dockSite.Loaded -= OnDockSiteLoaded;
    				dockSite.WindowRegistered -= OnDockSiteWindowRegistered;
    				dockSite.WindowUnregistered -= OnDockSiteWindowUnregistered;
    
    				// EO 2014-12-10, Added next lines
    				dockSite.WindowClosing -= dockSite_WindowClosing;
    				dockSite.LastActiveDocumentChanged -= DockSiteOnLastActiveDocumentChanged;
    			}
    		}
    
    		// ******************************************************************
    		void dockSite_WindowClosing(object sender, DockingWindowEventArgs e)
    		{
    			EnsureDockingWindowAssociatedModelIsClose(e.Window);
    		}
    
    		// ******************************************************************
    		private void DockSiteOnLastActiveDocumentChanged(object sender, DockingWindowPropertyChangedRoutedEventArgs dockingWindowPropertyChangedRoutedEventArgs)
    		{
    			var dockSite = sender as DockSite;
    			if (dockSite != null)
    			{
    				if (dockSite.ActiveWindow != null)
    				{
    					var frameWorkElement = dockSite.ActiveWindow.Content as FrameworkElement;
    					if (frameWorkElement != null)
    					{
    						ActiveModel = frameWorkElement.DataContext;
    						return;
    					}
    				}
    
    				ActiveModel = null;
    			}
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Called when <see cref="IsManagedProperty"/> is changed.
    		/// </summary>
    		/// <param name="d">The dependency object that was changed.</param>
    		/// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    		private static void OnDocumentSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			var behavior = d as DockSiteViewModelBehavior;
    			if (behavior == null)
    			{
    				throw new ArgumentNullException();				
    			}
    
    			var obsCollOld = e.OldValue as INotifyCollectionChanged;
    			if (obsCollOld != null)
    			{
    				obsCollOld.CollectionChanged -= behavior.ObjCollCollectionChanged;
    			}
    
    			var obsCollNew = e.NewValue as INotifyCollectionChanged;
    			if (obsCollNew != null)
    			{
    				obsCollNew.CollectionChanged += behavior.ObjCollCollectionChanged;
    			}
    		}
    
    		// ******************************************************************
    		void ObjCollCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    		{
    			// Find the DataTemplate
    			if (e.Action == NotifyCollectionChangedAction.Add)
    			{
    				foreach (object obj in e.NewItems)
    				{
    					// Here th obj Type is the key to the resource, it works but
    					var key = new System.Windows.DataTemplateKey(obj.GetType());
    					var dataTemplate = (DataTemplate)DockSite.FindResource(key);
    
    					var userControl = dataTemplate.LoadContent() as UserControl;
    					if (userControl != null)
    					{
    						userControl.DataContext = obj;
    
    						var documentWindow = new DocumentWindow(DockSite, null, "Title from viemodel", null, userControl);
    						documentWindow.Description = "viewModel.Description";
    
    						// Activate the document
    						documentWindow.Activate();
    					}
    				}
    			}
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Called when <see cref="IsManagedProperty"/> is changed.
    		/// </summary>
    		/// <param name="d">The dependency object that was changed.</param>
    		/// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    		private static void OnActiveModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			var behavior = d as DockSiteViewModelBehavior;
    			if (behavior == null)
    			{
    				return;
    			}
    
    			DockSite dockSite = behavior.AssociatedObject;
    
    			bool isAlreadyProperModelOfProperActiveWindow = false;
    
    			if (dockSite.ActiveWindow != null)
    			{
    				var frameworkElement = dockSite.ActiveWindow.Content as FrameworkElement;
    				if (frameworkElement != null)
    				{
    					if (frameworkElement.DataContext == behavior.ActiveModel)
    					{
    						isAlreadyProperModelOfProperActiveWindow = true;
    					}
    				}
    			}
    
    			if (!isAlreadyProperModelOfProperActiveWindow)
    			{
    				foreach (var docWin in dockSite.DocumentWindows)
    				{
    					var frameworkElement = docWin.Content as FrameworkElement;
    					if (frameworkElement != null)
    					{
    						if (frameworkElement.DataContext == behavior.ActiveModel)
    						{
    							docWin.Activate();
    						}
    					}
    				}
    			}
    
    			if (behavior.ActiveModelChanged != null)
    			{
    				behavior.ActiveModelChanged(behavior, new DependencyPropertyChangedEventArgs(ActiveModelProperty, e.OldValue, e.NewValue));
    			}
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Opens the specified docking window.
    		/// </summary>
    		/// <param name="dockSite">The dock site that owns the docking window.</param>
    		/// <param name="dockingWindow">The docking window to open.</param>
    		private static void OpenDockingWindow(DockSite dockSite, DockingWindow dockingWindow)
    		{
    			if (!dockingWindow.IsOpen)
    			{
    				if (dockingWindow is DocumentWindow)
    					dockingWindow.Open();
    				else
    				{
    					ToolWindow toolWindow = dockingWindow as ToolWindow;
    					ToolItemViewModel toolItemViewModel = dockingWindow.DataContext as ToolItemViewModel;
    					if (toolWindow != null && toolItemViewModel != null)
    					{
    						// Look for a ToolWindow within the same group, if found then dock to that group, otherwise either dock or auto-hide the window
    						ToolWindow targetToolWindow = GetToolWindow(dockSite, toolItemViewModel.DockGroup);
    						if (targetToolWindow != null && targetToolWindow != toolWindow)
    							toolWindow.Dock(targetToolWindow, Direction.Content);
    						else if (toolItemViewModel.IsInitiallyAutoHidden)
    							toolWindow.AutoHide(toolItemViewModel.DefaultDock);
    						else
    							toolWindow.Dock(dockSite, toolItemViewModel.DefaultDock);
    					}
    					else
    					{
    						dockingWindow.Open();
    					}
    				}
    			}
    		}
    		// ******************************************************************
    		public bool IsManaged
    		{
    			get { return (bool)GetValue(DockSiteViewModelBehavior.IsManagedProperty); }
    			set { SetValue(DockSiteViewModelBehavior.IsManagedProperty, value); }
    		}
    
    		// ******************************************************************
    		public object ModelsSource
    		{
    			get { return GetValue(ModelsSourceProperty); }
    			set { SetValue(ModelsSourceProperty, value); }
    		}
    
    		// ******************************************************************
    		public object ActiveModel
    		{
    			get { return GetValue(ActiveModelProperty); }
    			set { SetValue(ActiveModelProperty, value); }
    		}
    
    		// ******************************************************************
    		private static object GetDockinWindowDataContext(DockingWindow dockingWindow)
    		{
    			object dataContext = null;
    
    			if (dockingWindow != null)
    			{
    				var frameworkElement = dockingWindow.Content as FrameworkElement;
    				if (frameworkElement != null)
    				{
    					dataContext = frameworkElement.DataContext;
    				}
    			}
    
    			return dataContext;
    		}
    
    		// ******************************************************************
    
    	}
    }
