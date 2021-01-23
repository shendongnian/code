    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    public class CloseInventory : MonoBehaviour, IPointerDownHandler
    {
        GameObject inventoryPanel;
        // Use this for initialization
        void Start()
        {
            inventoryPanel = GameObject.Find("Inventory Panel");
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            //SET WHAT TO DO HERE
            inventoryPanel.SetActive(false);
        }
    }
