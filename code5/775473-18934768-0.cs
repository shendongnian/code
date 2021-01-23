    private void tsbRecortar_Click(object sender, EventArgs e){
      Point p = yourPictureBox.PointToClient(pbxSelection.PointToScreen(Point.Empty));
      Rectangle recorte = new Rectangle(p.X, p.Y, pbxSeleccion.Width, pbxSeleccion.Height);
      foto = recortarImagen(foto, recorte);
      pbxImagen.Image = foto;
    }
