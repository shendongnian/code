    Public Class Main
    Inherits System.Web.UI.Page
    
    Public Score = WebApplication1.login.Score
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CleanRubric
        Dim XRubric
        Dim YRubric
       
        CleanRubric = Rubric.Split(":")
