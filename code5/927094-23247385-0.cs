    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    
    namespace System
    {
    	/// <summary>Collection of common extensions.</summary>
    	public static class EventExtensions
    	{
    		/// <summary>Raises the specified event.</summary>
    		/// <param name="theEvent">The event.</param>
    		/// <param name="sender">The sender.</param>
    		/// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
    		public static void Raise(this EventHandler theEvent, object sender, EventArgs args = null)
    		{
    			if (theEvent != null)
    				theEvent(sender, args);
    		}
    		/// <summary>Raises the specified event.</summary>
    		/// <typeparam name="T">The type of the event argument.</typeparam>
    		/// <param name="theEvent">The event.</param>
    		/// <param name="sender">The sender.</param>
    		/// <param name="args">The arguments.</param>
    		public static void Raise<T>(this EventHandler<T> theEvent, object sender, T args) where T : EventArgs
    		{
    			if (theEvent != null)
    				theEvent(sender, args);
    		}
    		/// <summary>Raises the specified event.</summary>
    		/// <typeparam name="T">The value type contained in the EventArgs.</typeparam>
    		/// <param name="theEvent">The event.</param>
    		/// <param name="sender">The sender.</param>
    		/// <param name="args">The arguments.</param>
    		public static void Raise<T>(this EventHandler<EventArgs<T>> theEvent, object sender, T args)
    		{
    			if (theEvent != null)
    				theEvent(sender, new EventArgs<T>(args));
    		}
    		/// <summary>Raises the specified event.</summary>
    		/// <typeparam name="T">The value type contained in the EventArgs.</typeparam>
    		/// <param name="theEvent">The event.</param>
    		/// <param name="sender">The sender.</param>
    		/// <param name="newValue">The new value.</param>
    		/// <param name="oldValue">The old value.</param>
    		public static void Raise<T>(this EventHandler<ValueChangedEventArgs<T>> theEvent, object sender, T newValue, T oldValue)
    		{
    			if (theEvent != null)
    				theEvent(sender, new ValueChangedEventArgs<T>(newValue, oldValue));
    		}
    
    		/// <summary>Raises the specified event for every handler on its own thread.</summary>
    		/// <typeparam name="T">The value type contained in the EventArgs.</typeparam>
    		/// <param name="theEvent">The event.</param>
    		/// <param name="sender">The sender.</param>
    		/// <param name="args">The arguments.</param>
    		public static void RaiseAsync<T>(this EventHandler<EventArgs<T>> theEvent, object sender, T args)
    		{
    			if (theEvent != null)
    			{
    				var eventArgs = new EventArgs<T>(args);
    				foreach (EventHandler<EventArgs<T>> action in theEvent.GetInvocationList())
    					action.BeginInvoke(sender, eventArgs, null, null);
    			}
    		}
    	}
    }
