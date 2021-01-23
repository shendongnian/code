    Public Module MyExtensions
        <System.Runtime.CompilerServices.Extension()> _
        Public Function ToMyPredefinedClass(lvi As ListViewItem) As MyPredefinedClass
            Return New MyPredefinedClass(lvi)
        End Function
    End Module
