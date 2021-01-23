    using System;
    using System.Windows.Forms;
    
    namespace MyControlNameSpace
    {
        /// <summary>
        /// Data for a HoveredLinkChanged-Handler.
        /// </summary>
        public class HoveredLinkChangedEventArgs : EventArgs
        {
            private readonly LinkLabel.Link m_Link;
            /// <summary>
            /// Creates data for a HoveredLinkChanged-Handler
            /// </summary>
            /// <param name="link">the Link, with the mouse pointer over it</param>
            public HoveredLinkChangedEventArgs(LinkLabel.Link link)
            {
                m_Link = link;
            }
            /// <summary>
            /// Returns the hovered Link
            /// </summary>
            public LinkLabel.Link HoveredLink
            {
                get { return m_Link; }
            }
        }
        /// <summary>
        /// Adds to LinkLabel the possiblity to react on changes
        /// of the hovered Link (e.g. to alter a TooltipText).
        /// </summary>
        public class LinkLabelEx : LinkLabel
        {
            private Link m_HoveredLink;
        
            /// <summary>
            /// The Stucture of a HoveredLinkChanged-Handler
            /// </summary>
            public delegate void HoveredLinkChangedEventHandler(
                      object sender, HoveredLinkChangedEventArgs e);
    
            /// <summary>
            /// Occurs, when another Link is hovered.
            /// </summary>
            public event HoveredLinkChangedEventHandler HoveredLinkChanged;
    
            private void OnHoveredLinkChanged()
            {
                if (HoveredLinkChanged != null)
                    HoveredLinkChanged(this,
                        new HoveredLinkChangedEventArgs(m_HoveredLink));
            }
    
            /// <summary>
            /// Creates a new LinkLabel with notification on
            /// changes of the hovered Link.
            /// </summary>
            public LinkLabelEx()
            {
                MouseMove += LinkLabelEx_MouseMove;
            }
    
            void LinkLabelEx_MouseMove(object sender, MouseEventArgs e)
            {
                Link currentLink = PointInLink(e.X, e.Y);
                if (Equals(currentLink, m_HoveredLink)) return;
                m_HoveredLink = currentLink;
                OnHoveredLinkChanged();
            }
    
            ~LinkLabelEx()
            {
                MouseMove -= LinkLabelEx_MouseMove;
            }
        }
    }
