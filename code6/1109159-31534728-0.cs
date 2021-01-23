    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using System.Collections;
    public class UISegmentedControlButton : Button {
	public Sprite offSprite;
	public Sprite onSprite;
	public Color offTextColor = Color.white;
	public Color onTextColor = Color.white;
	private bool isSelected;
	public bool IsSelected {
		get {
			return isSelected;
		}
		set {
			isSelected = value;
			Text text = this.transform.GetComponentInChildren<Text>();
			if (value) {
				this.GetComponent<Image>().sprite = onSprite;
				text.color = onTextColor;
			} else {
				this.GetComponent<Image>().sprite = offSprite;
				text.color = offTextColor;
			}
		}
	}
	public override void OnPointerClick(PointerEventData eventData) {
		this.transform.parent.GetComponent<UISegmentedControl>().SelectSegment(this);
		base.OnPointerClick(eventData);
	}
    }
