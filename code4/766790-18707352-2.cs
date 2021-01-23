    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    namespace GridNavigationTest
    {
        public class GridNavigationBehavior : Behavior<DataGrid>
        {
            #region Overrides of Behavior
            /// <summary>
            /// Called after the behavior is attached to an AssociatedObject.
            /// </summary>
            /// <remarks>
            /// Override this to hook up functionality to the AssociatedObject.
            /// </remarks>
            protected override void OnAttached()
            {
                AssociatedObject.PreviewKeyDown += AssociatedObject_KeyDown;
            }
            /// <summary>
            /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
            /// </summary>
            /// <remarks>
            /// Override this to unhook functionality from the AssociatedObject.
            /// </remarks>
            protected override void OnDetaching()
            {
                AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
            }
            #endregion
            #region Event handlers
            void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.Key)
                {
                    case Key.J:
                        NavigateGridFocus(FocusNavigationDirection.Up);
                        break;
                    case Key.K:
                        NavigateGridFocus(FocusNavigationDirection.Down);
                        break;
                    case Key.X:
                        ToggleRowSelection();
                        break;
                }
            } 
            #endregion
            #region Methods
            private void ToggleRowSelection()
            {
                var currentlyFocusedRow = FindCurrentlyFocusedRow();
                if (currentlyFocusedRow == null)
                {
                    return;
                }
                var generator = AssociatedObject.ItemContainerGenerator;
                var rowItem = generator.ItemFromContainer(currentlyFocusedRow);
                if (AssociatedObject.SelectionMode == DataGridSelectionMode.Extended)
                {
                    if (AssociatedObject.SelectedItems.Contains(rowItem))
                    {
                        AssociatedObject.SelectedItems.Remove(rowItem);
                    }
                    else
                    {
                        AssociatedObject.SelectedItems.Add(rowItem);
                    }
                }
                else
                {
                    AssociatedObject.SelectedItem = AssociatedObject.SelectedItem == rowItem ? null : rowItem;
                }
            }
            private void NavigateGridFocus(FocusNavigationDirection direction)
            {
                var currentlyFocusedRow = FindCurrentlyFocusedRow();
                if (currentlyFocusedRow == null)
                {
                    return;
                }
                var traversalRequest = new TraversalRequest(direction);
                var currentlyFocusedElement = Keyboard.FocusedElement as UIElement;
                if (currentlyFocusedElement != null) currentlyFocusedElement.MoveFocus(traversalRequest);
            }
            private DataGridRow FindCurrentlyFocusedRow()
            {
                var generator = AssociatedObject.ItemContainerGenerator;
                if (generator.Status != GeneratorStatus.ContainersGenerated)
                {
                    return null;
                }
                for (var index = 0; index < generator.Items.Count - 1; index++)
                {
                    var row = generator.ContainerFromIndex(index) as DataGridRow;
                    if (row != null && row.IsKeyboardFocusWithin)
                    {
                        return row;
                    }
                }
                return null;
            }
            #endregion
        }
    } 
