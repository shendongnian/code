	using UnityEngine;
	using System.Collections;
	
	public class EnemyMovement : MonoBehaviour  {
	
	    CharacterController _controller;
	    Transform _player;
	
	    [SerializeField]
	    float _moveSpeed = 5.0f;
	
	    [SerializeField]
	    float _gravity = 2.0f;
	
	    float _yvelocity = 0.0f;
	    // max distance enemy can be before he moves towards you    
	    float maxDistance = 15.0f;
	
	    float attackDistance = 5.0f;
	
	    Animation _animation;
		
		/// <summary>
		/// The _enemy is in run range.
		/// </summary>
		bool _enemyIsInRunRange = false;
		/// <summary>
		/// The _enemy is in attack range.
		/// </summary>
		bool _enemyIsInAttackRange = false;
		/// <summary>
		/// "Run Range" block flag. 
		/// </summary>
		bool _enemyIsInRunRangeBlock = false;
		/// <summary>
		/// "Attack Range" block flag.
		/// </summary>
		bool _enemyIsInAttackRangeBlock = false;
		
	
	    void Start()
	    {
	        _animation = GetComponentInChildren<Animation>(); 
	
	        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
	        _player = playerGameObject.transform;
	        _controller = GetComponent<CharacterController>();
	
	        _animation.CrossFade("idle1_"); 
	    }
	
	    void Update()
	    {
	        Vector3 direction = _player.position - transform.position;
	
	        transform.rotation = Quaternion.LookRotation(direction);
	
	        Vector3 velocity = direction * _moveSpeed;
	
	        if (!_controller.isGrounded)
	        {
	            _yvelocity -= _gravity;
	        }
	
	        velocity.y = _yvelocity;
	
	        direction.y =0;
			
			
			// Setted two bools here with your distance calculations
			_enemyIsInRunRange = Vector3.Distance(_player.position, transform.position) < maxDistance;
			_enemyIsInAttackRange = Vector3.Distance(_player.position, transform.position) < attackDistance;
			
			// If enemy is in "Run" range
	        if (_enemyIsInRunRange) {
				
				// Do other stuff when the enemy is inside the "Run" range (Remember that here is one call per frame, that's why we made the block flags)
				
				_controller.Move(velocity*Time.deltaTime);
				
				// Check if there's a flag to block, if not we call the CrossFade and raise the Run Block flag up
				if(!_enemyIsInRunRangeBlock){
	            	_animation.CrossFade("run_");
					// Raising the block so this will be called only once until the enemy goes out of the "Run" range
					_enemyIsInRunRangeBlock = true;
				}
	        }
			// if not in "Run" range, we drop the flag
			else
			{
				_enemyIsInRunRangeBlock = false;
			}
			
			// if the enemy is in the Attack Range
	        if (_enemyIsInAttackRange) {
				
				// Do other stuff when the enemy is inside the "Attack" range (Remember that here is one call per frame)
				
				// Check if theres a "Attack Block" flag down and call the CrossFade
				if(!_enemyIsInAttackRangeBlock){
					// Calling Cross Fade only once
	            	_animation.CrossFade("hornAttack1_", 0.5f);
					// Raising the block so this will be called only once until the enemy goes out of the "Attack" range
					_enemyIsInAttackRangeBlock = true;
				}
	        }
			// If enemy is out of range for a Attack we drop the flag
			else
			{
				_enemyIsInAttackRangeBlock = false;
			}
	    }
	}
 
