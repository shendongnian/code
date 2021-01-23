    protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _context = new IMSDBContext();
                switch (btnDelete.Text)
                {
                    case DeleteButton:
                        if (txtLocationName.Text != null && txtSubAccountName.Text != null)
                        {
                            Location location = _context.Locations.ToList()
                                                .First(x => x.Name == txtLocationName.Text && x.SubAccount == txtSubAccountName.Text);
                            _context.Locations.Remove(location);
                            _context.SaveChanges();
                            
                            PopulateLocationGridView();
                            grdvwLocationList.SelectedIndex = 0;
                            RowSelected();
                        }
                        break;
                    case CancelButton:
                        Reload();
                        break;
                }
            }
            catch (Exception ex)
            {
                lblLocationNameNotification.Text = ex.Message;
            }
            finally
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
