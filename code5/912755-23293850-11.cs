    using System.Drawing;
    using Microsoft.Office.Interop.PowerPoint;
    using System;
    namespace PowerPointDynamicLink.PPObject
    {
        class PPShape
        {
            #region Fields
            protected Shape shape;
            /// <summary>
            /// Get the PowerPoint Shape this object is based on
            /// </summary>
            public Shape Shape
            {
                get { return shape; }
            }
            protected long id;
            /// <summary>
            /// Get or set the Id of the Shape
            /// </summary>
            public long Id
            {
                get { return id; }
                set { id = value; }
            }
        
            protected string name;
            /// <summary>
            /// Get or set the name of the Shape
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            /// <summary>
            /// Gets the bounding box of the shape in PowerPoint Point-units
            /// </summary>
            public RectangleF Rectangle
            {
                get
                {
                    RectangleF rect = new RectangleF
                    {
                        X = shape.Left,
                        Y = shape.Top,
                        Width = shape.Width,
                        Height = shape.Height
                    };
                    return rect;
                }
            }
            #endregion
            #region Constructor
            /// <summary>
            /// Creates a new PPShape object
            /// </summary>
            /// <param name="shape">The PowerPoint shape this object is based on</param>
            public PPShape(Shape shape)
            {
                this.shape = shape;
                this.name = shape.Name;
                this.id = shape.Id;
            }
            #endregion
            #region Event handling
            #region MouseEntered
            /// <summary>
            /// An event that notifies listeners when the mouse has entered this shape
            /// </summary>
            public event EventHandler MouseEntered = delegate { };
            /// <summary>
            /// Raises an event telling listeners that the mouse has entered this shape
            /// </summary>
            internal void OnMouseEntered()
            {
                // Raise the event
                MouseEntered(this, new EventArgs());
            }
            #endregion
            #region MouseLeave
            /// <summary>
            /// An event that notifies listeners when the mouse has left this shape
            /// </summary>
            public event EventHandler MouseLeave = delegate { };
            /// <summary>
            /// Raises an event telling listeners that the mouse has left this shape
            /// </summary>
            internal void OnMouseLeave()
            {
                // Raise the event
                MouseLeave(this, new EventArgs());
            }
            #endregion
            #endregion
        }
    }
