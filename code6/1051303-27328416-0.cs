     using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;
    
    namespace Combo_MiddleText_AutocompleteDemo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                //don't forget to create/initialize our own autocomplete listbox
                this.InitializeAutoComplete();
            }
            private void InitializeAutoComplete()
            {
                this.SuspendLayout();
                //Create a new listbox that will be shown for the auto-complete
                // 
                // _listBox
                // 
                _listBox = new System.Windows.Forms.ListBox();
                _listBox.Visible = false;
                _listBox.Location = new System.Drawing.Point(0, 0);
                _listBox.Name = "_listBox";
                _listBox.Size = new System.Drawing.Size(120, 96);
                _listBox.TabIndex = 0;
                _listBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this._listBox_MouseDown);
                // 
                // AutoCompleteTextBox - attach some events
                // 
                cmbMenuName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMenuName_KeyDown);
                cmbMenuName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbMenuName_KeyUp);
                this.ResumeLayout(false);
            }
            #region Variables
        Hashtable hash;
        private String[] _values;
        private ListBox _listBox;
        private bool _isAdded;
        private String _formerValue = String.Empty;
        #endregion Variables
        private void Form1_Load(object sender, EventArgs e)
        {
            FillGrid(125);// Menu combobox in Quotation Menu Grid
            cmbMenuName.DroppedDown = false;
        }
        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();
                DataTable dtReturn = new DataTable();
                hash.Add("@QueryNo", QueryNo);
                //dtReturn= ClsDefination.FillData()
                dtReturn = ClsDefination.FillData("[usp_Transaction_QuotationMaster_Select]", hash);
                if ((dtReturn != null && dtReturn.Rows.Count > 0))// || dtReturn2 != null && dtReturn2.Rows.Count > 0)
                {
                    DataRow objRow = dtReturn.Rows[0];
                    if (QueryNo == 125) // Menu Name
                    {
                        cmbMenuName.DataSource = dtReturn;
                        cmbMenuName.DisplayMember = "MenuName";
                        cmbMenuName.ValueMember = "MenuID";
                        cmbMenuName.Text = "";
                        List<string> list = new List<string>();
                        for (int i = 0; i < dtReturn.Rows.Count; i++)
                        {
                            DataRow dr = dtReturn.Rows[i];
                            list.Add(dr["MenuName"].ToString());
                        }
                        _values = list.ToArray();
                    }
                }
                else
                {
                }
                return null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        private void cmbMenuName_KeyDown(object sender, KeyEventArgs e)
        {
            //react the arrow up and down
            switch (e.KeyCode)
            {
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                        {
                            _listBox.SelectedIndex++;
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                        {
                            _listBox.SelectedIndex--;
                        }
                        break;
                    }
            }
        }
        private void cmbMenuName_KeyUp(object sender, KeyEventArgs e)
        {
            //whenever a key is pressed, update the listbox content
            UpdateListBox();
        }
        private void _listBox_MouseDown(object sender, MouseEventArgs e)
        {
            //select the item with the mouse
            if (_listBox.Visible)
            {
                InsertWord((String)_listBox.SelectedItem);
                HideListBox();
                _formerValue = cmbMenuName.Text;
            }
        }
        private void HideListBox()
        {
            //Hide the listbox
            _listBox.Visible = false;
        }
        //private void btnShow_Click(object sender, EventArgs e)
        //{
        //    //when this button is clicked, 
        //    //we take the values from the textbox and list them into the second listbox
        //    lstSelectedValues.Items.Clear();
        //    List<String> selectedValues = SelectedValues;
        //    Array.ForEach(selectedValues.ToArray(),
        //                  selectedValue => lstSelectedValues.Items.Add(selectedValue.Trim()));
        //}
        public List<String> SelectedValues
        {
            get
            {
                //return the list of selection
                String[] result = cmbMenuName.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                return new List<String>(result);
            }
        }
        private void UpdateListBox()
        {
            //fill the listbox with the new filtered values
            if (cmbMenuName.Text != _formerValue)
            {
                _formerValue = cmbMenuName.Text;
                String word = GetWord();
                if (word.Length > 0)
                {
                    //case insensitive search
                    String[] matches = Array.FindAll(_values, x => (x.ToUpper().Contains(word.ToUpper()) && !SelectedValues.Contains(x)));
                    if (matches.Length > 0)
                    {
                        ShowListBox();
                        _listBox.Items.Clear();
                        Array.ForEach(matches, x => _listBox.Items.Add(x));
                        _listBox.SelectedIndex = 0;
                        _listBox.Height = 0;
                        //at least the same width as the textbox
                        _listBox.Width = cmbMenuName.Width;
                        //  cmbMenuName.Focus();
                        using (Graphics graphics = _listBox.CreateGraphics())
                        {
                            for (int i = 0; i < _listBox.Items.Count; i++)
                            {
                                _listBox.Height += _listBox.GetItemHeight(i);
                                // it item width is larger than the current one
                                // set it to the new max item width
                                // GetItemRectangle does not work for me
                                // we add a little extra space by using '_'
                                int itemWidth = (int)graphics.MeasureString(((String)_listBox.Items[i]) + "_", _listBox.Font).Width;
                                _listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : _listBox.Width;
                            }
                        }
                    }
                    else
                    {
                        HideListBox();
                    }
                }
                else
                {
                    HideListBox();
                }
            }
        }
        private void ShowListBox()
        {
            //display the listbox just below the textbox
            if (!_isAdded)
            {
                this.Controls.Add(_listBox);
                _listBox.Left = cmbMenuName.Left;
                _listBox.Top = cmbMenuName.Top + cmbMenuName.Height;
                _isAdded = true;
            }
            _listBox.Visible = true;
        }
        private String GetWord()
        {
            //get the current word (useful when there is more than one on the textbox)
            String text = cmbMenuName.Text;
            int pos = cmbMenuName.SelectionStart;
            int posStart = text.LastIndexOf(';', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(';', pos);
            posEnd = (posEnd == -1) ? text.Length : posEnd;
            int length = ((posEnd - posStart) < 0) ? 0 : posEnd - posStart;
            return text.Substring(posStart, length);
        }
        private void InsertWord(String newTag)
        {
            //add the new selection to the textbox
            String text = cmbMenuName.Text;
            int pos = cmbMenuName.SelectionStart;
            int posStart = text.LastIndexOf(';', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(';', pos);
            String firstPart = text.Substring(0, posStart) + newTag;
            String updatedText = firstPart + ((posEnd == -1) ? "" : text.Substring(posEnd, text.Length - posEnd));
            cmbMenuName.Text = updatedText;
            cmbMenuName.SelectionStart = firstPart.Length;
        }
        private void cmbMenuName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab) && (_listBox.Visible))
            {
                InsertWord((String)_listBox.SelectedItem);
                HideListBox();
                _formerValue = cmbMenuName.Text;
            }
        }
        private void cmbMenuName_KeyDown_1(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        
