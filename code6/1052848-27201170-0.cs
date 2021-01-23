    Using b As New SolidBrush(Color.Black)
        Using p As New Pen(b)
            Debug.WriteLine("Is equal: {0}", (b Is p.Brush))
        End Using
    End Using
