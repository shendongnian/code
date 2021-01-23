using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Extensions;
using UnityEngine.EventSystems;
public class PlayerInGameMenu : RealtimeMonoBehavior
{
  public EventSystem eventSystem;
  Selectable SelectedButton;
  public Selectable Status;
  public Selectable Settings;
  public Selectable Save;
  public Selectable Quit;
  public float ButtonThreashold;
  public bool Paused;
  List&lt;Selectable&gt; buttons;
  int selectedButtonIndex;
  public PlayerMovement PlayerMovement;
  public Canvas Menu;
  public override void RealtimeIntervalStart()
  {
    base.RealtimeIntervalStart();
    Menu.enabled = false;
    buttons = new List&lt;Selectable&gt;();
    buttons.Add(Status);
    buttons.Add(Settings);
    buttons.Add(Save);
    buttons.Add(Quit);
    selectedButtonIndex = 0;
    SelectedButton = buttons[selectedButtonIndex];
    eventSystem.SetSelectedGameObject(SelectedButton.gameObject, new BaseEventData(eventSystem));
    
  }
  public override void DefaultIntervalUpdate()
  {
    base.DefaultIntervalUpdate();
    if (cInput.GetKeyDown("Pause"))
    {
      Paused = !Paused;
    }
  }
  public override void RealtimeIntervalUpdate()
  {
    base.RealtimeIntervalUpdate();
    
    CheckInput();
    if (Paused && !Menu.enabled)
    {
      ShowMenu();
    }
    else if (!Paused && Menu.enabled)
    {
      HideMenu();
    }
  }
  void ShowMenu()
  {
    Paused = true;
    Menu.enabled = true;
    Time.timeScale = 0.0f;
  }
  void HideMenu()
  {
    if (Menu.enabled)
    {
      Paused = false;
      Menu.enabled = false;
      Time.timeScale = 1.0f;
    }
  }
  void CheckInput()
  {
    if (Paused)
    {
      float v = Input.GetAxisRaw("Vertical");
      if (v &gt; ButtonThreashold)
      {
        GoUp();
      }
      else if (v &lt; -ButtonThreashold)
      {
        GoDown();
      }
      SelectedButton = buttons[selectedButtonIndex];
      eventSystem.SetSelectedGameObject(SelectedButton.gameObject, new BaseEventData(eventSystem));
    }
  }
  void GoDown()
  {
    if (selectedButtonIndex &lt; buttons.Count - 1)
    {
      selectedButtonIndex = selectedButtonIndex + 1;
    }
  }
  void GoUp()
  {
    if (selectedButtonIndex &gt; 0)
    {
      selectedButtonIndex = selectedButtonIndex - 1;
    }
  }
}
