    **I also have similar problems in visual studio 2013**
    
    Private Sub ButtonProses_Click(sender As Object, e As EventArgs) Handles ButtonProses.Click
                Dim index As Integer
                If TextIDSupp.Text = "" Then
                    MsgBox("Data Suplier tidak boleh kosong!")
                    TextIDSupp.Focus()
                ElseIf DataGridView1.Item(0, index).Value = "" Then
                    MsgBox("Transaksi pembelian masih kosong")
                    TextKodeBR.Focus()
                Else
                    'simpan tabel pembelian
                    Koneksi()
                    CMD = New SqlCommand("INSERT INTO tbl_pembelian (no_pembelian,tanggal_pembelian,id_supplier,total_barang,total_harga) VALUES (@no_pembelian, @tanggal_pembelian, @id_supplier, @total_barang, @total_harga)", CONN)
                    With CMD
                        .Parameters.AddWithValue("@no_pembelian", TextNoTrans.Text)
                        .Parameters.AddWithValue("@tanggal_pembelian", TextTglTrans.Text)
                        .Parameters.AddWithValue("@id_supplier", TextIDSupp.Text)
                        .Parameters.AddWithValue("@total_barang", TextTotalBR.Text)
                        .Parameters.AddWithValue("@total_harga", TextTotalHgBR.Text)
                        .ExecuteNonQuery()
                    End With
                    CONN.Close()
        
                    For i As Integer = 0 To DataGridView1.RowCount - 2
        
                        'simpan tabel pembelian detail
                        Koneksi()
                        CMD = New SqlCommand("INSERT INTO tbl_pembelian_detail (no_pemebelian, kode_barang, Qty, harga_barang, sub_total_harga) VALUES (@no_pemebelian, @kode_barang, @Qty, @harga_barang, @sub_total_harga)", CONN)
                        With CMD
                            .Parameters.AddWithValue("@no_pemebelian", TextNoTrans.Text)
                            .Parameters.AddWithValue("@kode_barang", DataGridView1.Item(0, i).Value)
                            .Parameters.AddWithValue("@Qty", DataGridView1.Item(2, i).Value)
                            .Parameters.AddWithValue("@harga_barang", DataGridView1.Item(4, i).Value)
                            .Parameters.AddWithValue("@sub_total_harga", DataGridView1.Item(5, i).Value)
                            .ExecuteNonQuery()
                        End With
                        CONN.Close()
        
                        'update tabel barang 
                        Koneksi()
                        CMD = New SqlCommand("SELECT stock FROM tbl_barang WHERE kode_barang ='" + DataGridView1.Item(0, i).Value + "'", CONN)
                        DRead = CMD.ExecuteReader
                        DRead.Read()
                        If DRead.HasRows Then
                            Dim jumlah As String
                            jumlah = DRead(0) + DataGridView1.Item(2, i).Value
        
                            Koneksi()
                            CMD = New SqlCommand("UPDATE tbl_barang SET stock ='" + jumlah + "' WHERE kode_barang='" + DataGridView1.Item(0, i).Value + "'", CONN)
                            CMD.ExecuteNonQuery()
                            CONN.Close()
                        End If
                        CONN.Close()
        
                    Next
        
                    MsgBox("Data berhasil disimpan")
                    call_all()
                End If
            End Sub
