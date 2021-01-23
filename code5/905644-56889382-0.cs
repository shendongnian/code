    Imports System
    Imports System.Collections.Generic
    Imports System.Runtime.CompilerServices
    Public Class TimeUnit
        Private ReadOnly _name As String
        Public Sub New(ByVal name As String, ByVal avgSpan As TimeSpan)
            _name = name
            _AvgSpan = avgSpan
        End Sub
        Public ReadOnly Property AvgSpan() As TimeSpan
        Public Overrides Function ToString() As String
            Return _name
        End Function
    End Class
    Public Class TimeUnits
        Private ReadOnly _items As New Dictionary(Of String, TimeUnit)(37, StringComparer.OrdinalIgnoreCase) _
            From {{{"n", "min", "minute", "minutes", "minuten"},
                   New TimeUnit("Minute", TimeSpan.FromMinutes(1))},
                  {{"h", "std", "stunde", "hour", "stunden", "hours"},
                   New TimeUnit("Hour", TimeSpan.FromHours(1))},
                  {{"d", "t", "day", "tag", "days", "tage"},
                   New TimeUnit("Day", TimeSpan.FromDays(1))},
                  {{"m", "mo", "month", "monat", "months", "monate"},
                   New TimeUnit("Month", TimeSpan.FromDays(30.4375))},
                  {{"q", "quarter", "quartal", "quarters", "quartale"},
                   New TimeUnit("Quarter", TimeSpan.FromDays(91.3125))},
                  {{"y", "yy", "yyy", "yyyy", "j", "year", "jahr", "years", "jahre"},
                   New TimeUnit("Year", TimeSpan.FromDays(365.25))}}
        Public Function GetByAbbreviation(ByVal abbreviation As String) As TimeUnit
            Return _items(abbreviation)
        End Function
    End Class
    Public Module ExtensionMethods
        <Extension>
        Public Sub Add(Of TKey, TValue)(ByVal valItems As IDictionary(Of TKey, TValue), ByVal valKeys As IEnumerable(Of TKey), ByVal valValue As TValue)
            For Each tempKey As TKey In valKeys
                valItems.Add(tempKey, valValue)
            Next
        End Sub
    End Module
    Public Module Main
        Public Sub Main()
            Dim name As String = "Jahr"
            Console.WriteLine(String.Format("The time unit for '{0}' is {1}.", name, (New TimeUnits).GetByAbbreviation(name)))
        End Sub
    End Module
