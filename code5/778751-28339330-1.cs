        delegate void myDelegate();
        private void fileOpenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Thread ViewportLoaderThread = new Thread(loadViewportItemsAsync);
                ViewportLoaderThread.IsBackground = true;
                ViewportLoaderThread.Start();
            }
            catch (Exception err) { UtilsProgram.writeErrorLog(err.ToString()); }
        }
        private void loadViewportItemsAsync()
        {
            try
            {
                //TRY to browse for a file
                if (!browseForFile()) return;
                Dispatcher.Invoke(new Action(() => { myStatusBar.Visibility = System.Windows.Visibility.Visible; menuItemHelpDemo.IsEnabled = false; }), null);
                //Load file, unpack, decrypt, load STLs and create ModelGroup3D objects
                UtilsDen.DenModel = new DenLoader(UtilsDen.Filename, UtilsDen.Certificate, UtilsDen.PrivateKey, this);
                //Load the models to viewport async
                myDelegate asyncDel = new myDelegate(sendModelsToViewportAsync);
                this.Dispatcher.BeginInvoke(asyncDel, null);
            }
            catch (Exception err) { MessageBox.Show(UtilsProgram.langDict["msg18"]); UtilsProgram.writeErrorLog(err.ToString()); }
        }
        private void sendModelsToViewportAsync()
        {
            for (int i = 0; i < UtilsDen.DenModel.StlFilesCount; i++)
            {
                //Add the models to MAIN VIEWPORT
                ModelVisual3D modelVisual = new ModelVisual3D();
                GeometryModel3D geometryModel = new GeometryModel3D();
                Model3DGroup modelGroup = new Model3DGroup();
                
                geometryModel = new GeometryModel3D(UtilsDen.DenModel.StlModels[i].MeshGeometry, UtilsDen.Material);
                modelGroup.Children.Add(geometryModel);
                modelVisual.Content = modelGroup;
                mainViewport.Children.Add(toothModelVisual);
            }
        }
